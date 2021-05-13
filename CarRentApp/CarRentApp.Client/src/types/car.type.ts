export declare module Car {
  export type Car = {
    id: number;
    brand: string;
    color: string;
    fuel: string;
    transmission: string;
    body: string;
    fabricationYear: Date;
    registrationNumber: string;
    model: string;
    numberOfSeats: number;
    numberOfDoors: number;
    airCoditioning: boolean;
    pricePerDay: number;
    photos: Photo[];
  };

  export type CarPreview = {
    id: number;
    brand: string;
    model: string;
    pricePerDay: number;
    photos: Photo[];
  };

  export type Photo = {
    carId: number;
    path: string;
  };
}
