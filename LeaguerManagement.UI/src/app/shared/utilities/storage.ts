export class AppStorage {
  static getTokenData(dataKey: string): string {
    const token = localStorage.getItem(dataKey);
    return token ? decodeURIComponent(atob(token)) : '';
  }

  static storeTokenData(dataKey: string, data: any) {
    localStorage.setItem(dataKey, btoa(encodeURIComponent(data)));
  }

  static storeSessionData(key: string, data: any) {
    const jsonString = JSON.stringify(data);
    sessionStorage.setItem(key, btoa(encodeURIComponent(jsonString)));
  }

  static getSessionData(key: string): any {
    const encodedData = sessionStorage.getItem(key);
    if (!!encodedData) {
      const data = decodeURIComponent(atob(encodedData));
      return data ? JSON.parse(data) : null;
    }
    return null;
  }

  static removeSessionData(key: string) {
    sessionStorage.removeItem(key);
  }
}

