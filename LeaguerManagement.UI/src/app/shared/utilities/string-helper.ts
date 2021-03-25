declare global {
  interface String {
    format(...replacements: any[]): string;
  }
}

String.prototype.format = function(): string {
  const args = arguments;
  // tslint:disable-next-line:variable-name
  return this.replace(/{(\d+)}/g, (match, number) => {
    return typeof args[number] !== 'undefined' ? args[number] : match;
  });
};

export {};
