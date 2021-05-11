import React, { createContext, useState } from "react";
import { v1 as uuid1 } from "uuid";

import { Car, Snackbar } from "types";
import { SnackbarProps } from "components/snackbar";

export type CarRentAppContextValues = {
  snackbars: Snackbar.Snackbar[];
  cars: Car.Car[];
  handlers: {
    addSnackbar: (props: SnackbarProps) => void;
    setCars: React.Dispatch<React.SetStateAction<Car.Car[]>>;
  };
};

const CarRentAppContext = createContext<CarRentAppContextValues>(
  {} as CarRentAppContextValues
);

const CarRentAppProvider: React.FC = (props) => {
  const [cars, setCars] = useState<Car.Car[]>([]);
  const [snackbars, setSnackbars] = useState<Snackbar.Snackbar[]>([]);

  const addSnackbar = (props: SnackbarProps) => {
    const newSnackbar = {
      ...props,
      id: uuid1(),
    };

    setSnackbars((prevSnackbars) => [...prevSnackbars, newSnackbar]);

    setTimeout(() => {
      setSnackbars((prevSnackbars) =>
        prevSnackbars.filter((snackbar) => snackbar.id !== newSnackbar.id)
      );
    }, 4000);
  };

  const contextValues = {
    snackbars,
    cars,
    handlers: { addSnackbar, setCars },
  };

  return (
    <CarRentAppContext.Provider value={contextValues}>
      {props.children}
    </CarRentAppContext.Provider>
  );
};

export { CarRentAppProvider, CarRentAppContext };
