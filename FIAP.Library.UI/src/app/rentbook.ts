export class RentBook {

    constructor(
      public id: number,
      public rentalDate: string,
      public deletionDate: string,
      public duoDate: string,
      public customerId: number,
      public bookId: number,
      public status?: string
    ) {  }
  
  }
  