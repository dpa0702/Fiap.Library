export class Customer {

  constructor(
    public id: number,
    public name: string,
    public phone: string,
    public email: string,
    public address: string,
    public document?: string
  ) {  }

}
