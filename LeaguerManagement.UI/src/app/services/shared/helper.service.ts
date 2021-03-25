import {Injectable} from '@angular/core';
// import {NgxImageCompressService} from 'ngx-image-compress';
import {ImageUtility} from '../../shared/utilities';

@Injectable()
export class HelperService {
  // private imageCompress: NgxImageCompressService
  constructor() {

  }

  async compressImage(files: File[]) {
    const filesReduce = [];
    const orientation = -1;

    // const filesResult = await ImageUtility.readFiles(files);
    // for (const file of filesResult) {
    //   const result = await this.imageCompress.compressFile(file.base64, orientation, 50, 50);
    //   filesReduce.push(new File([result], file.name, {type: file.type}));
    // }

    return filesReduce;
  }
}
