import React, { createContext, useCallback, useState } from "react";
import { v1 as uuid1 } from "uuid";

import { Car, Snackbar, User } from "types";
import { SnackbarProps } from "components/snackbar";

export type CarRentAppContextValues = {
  snackbars: Snackbar.Snackbar[];
  cars: Car.Car[];
  user: User.User | null;
  handlers: {
    addSnackbar: (props: SnackbarProps) => void;
    setCars: React.Dispatch<React.SetStateAction<Car.Car[]>>;
    setUser: React.Dispatch<React.SetStateAction<User.User | null>>;
  };
};

const CarRentAppContext = createContext<CarRentAppContextValues>(
  {} as CarRentAppContextValues
);

const CarRentAppProvider: React.FC = (props) => {
  const [user, setUser] = useState<User.User | null>(null);
  const [cars, setCars] = useState<Car.Car[]>([]);
  const [snackbars, setSnackbars] = useState<Snackbar.Snackbar[]>([]);

  const addSnackbar = useCallback((props: SnackbarProps) => {
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
  }, []);

  const contextValues = {
    snackbars,
    cars,
    user,
    handlers: { addSnackbar, setCars, setUser },
  };

  return (
    <CarRentAppContext.Provider value={contextValues}>
      {props.children}
    </CarRentAppContext.Provider>
  );
};

export { CarRentAppProvider, CarRentAppContext };
