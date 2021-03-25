export class ImageUtility {

  static setAvatar(object: any) {
    if (!object.avatarImg) {
      object.nameAvatar = ImageUtility.getAvatarName(object.firstName, object.lastName);
    } else {
      // object.avatarImg = ImageUtility.replaceImagesLinks(object.avatarImg);
    }
  }

  static getAvatarName(firstName: string, lastName: string) {
    let result = '';
    if (firstName) {
      result += firstName.substr(0, 1).toUpperCase();
    }

    if (lastName) {
      result += lastName.substr(0, 1).toUpperCase();
    }

    return result;
  }

  static async readFiles(files: File[]) {
    const base64List = [];

    for (const file of files) {
      const base64 = await this.readFile(file);

      base64List.push(new Object({
        base64,
        name: file.name,
        type: file.type
      }));
    }

    return base64List;
  }

  static readFile(file) {
    return new Promise((resolve, reject) => {
      const fr = new FileReader();
      fr.onload = () => {
        resolve(fr.result);
      };
      fr.readAsDataURL(file); // or readAsText(file) to get raw content
    });
  }

  static filterFileImage(files: File[]): File[] {
    const imageFiles = [];
    const pattern = /image-*/;
    files.forEach((file) => {
      if (file.type.match(pattern)) {
        imageFiles.push(file);
      }
    });

    return imageFiles;
  }

  static filterFileIsNotImage(files: File[]): File[] {
    const imageFiles = [];
    const pattern = /image-*/;
    files.forEach((file) => {
      if (!file.type.match(pattern)) {
        imageFiles.push(file);
      }
    });

    return imageFiles;
  }

  static isGreaterThan1Mb(size: number) {
    return size / 1024 / 1024 > 1;
  }
}
