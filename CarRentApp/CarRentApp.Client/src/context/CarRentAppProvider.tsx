import React, { createContext, useState } from "react";
import { v1 as uuid1 } from "uuid";

import { Snackbar } from "types";
import { SnackbarProps } from "components/snackbar";

export type CarRentAppContextValues = {
  snackbars: Snackbar.Snackbar[];
  handlers: {
    addSnackbar: (props: SnackbarProps) => void;
  };
};

const CarRentAppContext = createContext<CarRentAppContextValues>(
  {} as CarRentAppContextValues
);

const CarRentAppProvider: React.FC = (props) => {
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
    handlers: { addSnackbar },
  };

  return (
    <CarRentAppContext.Provider value={contextValues}>
      {props.children}
    </CarRentAppContext.Provider>
  );
};

export { CarRentAppProvider, CarRentAppContext };
