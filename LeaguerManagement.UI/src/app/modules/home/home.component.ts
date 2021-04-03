import {Component, ElementRef, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {DropDownModel, LeaguerModel} from '@app/models';
import {Subscription} from 'rxjs';
import {LookupService} from '@app/services/shared';
import {GENERAL_MESSAGE} from '@app/shared/messages';
import {LeaguerService} from '@app/services/features/leaguer.service';
import DataSource from 'devextreme/data/data_source';
import {Router} from '@angular/router';
import {GENDER_ITEMS} from '@app/shared/constants';
import {PopoverConfirmBoxComponent} from '@app/shared/base-components/popover-confirm-box/popover-confirm-box.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnDestroy {
  @ViewChild('deletingConfirmBox', {static: true}) deletingConfirmBox: PopoverConfirmBoxComponent;
  @ViewChild('deletingAccessControlConfirmBox', {static: true}) deletingAccessControlConfirmBox: PopoverConfirmBoxComponent;
  @ViewChild('streaming', {static: false}) streamingCanvas: ElementRef;

  pageSize = 20;
  dataSource: DataSource;

  units: DropDownModel[] = [];
  files: LeaguerModel[] = [];
  selectedFile: LeaguerModel = new LeaguerModel();

  isShowEditingPopup: boolean = false;
  isLoading: boolean = false;
  isProcessing: boolean = false;

  genderItems = GENDER_ITEMS;
  GENERAL_MESSAGE = GENERAL_MESSAGE;
  subscription: Subscription = new Subscription();

  constructor(private fileService: LeaguerService,
              private router: Router,
              private lookupService: LookupService) {
    this.subscription.add(
      this.lookupService.lookup.subscribe(lookup => {
        this.units = lookup.units;
      }));
  }

  ngOnInit() {
    this.getCurrentStaffs();
  }

  getCurrentStaffs() {
    this.dataSource = new DataSource({
      load: (loadOptions) => {
        loadOptions.requireTotalCount = true;
        return this.fileService.getCurrentLeaguers(loadOptions).toPromise();
      }
    });
  }

  contentReady(e) {
    if (!e.component.getSelectedRowKeys().length) {
      e.component.selectRowsByIndexes(0);
    }
  }

  selectionChanged(e) {
    e.component.collapseAll(-1);
    e.component.expandRow(e.currentSelectedRowKeys[0]);
    this.selectedFile = e.currentSelectedRowKeys[0];
  }

  refresh() {
    setTimeout(() => {
      this.getCurrentStaffs();
    }, 100);
  }

  goToDetail(data: LeaguerModel) {
    this.router.navigate([`/staffs/${data.id}`]).then();
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
