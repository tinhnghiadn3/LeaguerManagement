import { Component, OnInit } from '@angular/core';
import {LeaguerService} from '@app/services/features/leaguer.service';
import {DocumentationModel} from '@app/models';

@Component({
  selector: 'app-documentation',
  templateUrl: './documentation.component.html',
  styleUrls: ['./documentation.component.scss']
})
export class DocumentationComponent implements OnInit {

  isLoading: boolean = false;
  isProcessing: boolean = false;

  documentations: DocumentationModel[] = [];

  constructor(private leaguerService: LeaguerService) { }

  ngOnInit(): void {
  }

  getStatusStatistic() {
    this.isLoading = true;
    this.leaguerService.getStatusStatistics().subscribe(res => {
      this.documentations = res;
      this.isLoading = false;
    }, () => {
      this.isLoading = false;
    });
  }

}
