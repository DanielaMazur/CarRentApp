import { useContext } from "react";

import { CarRentAppContext } from "./CarRentAppProvider";

const useCarRentAppContext = () => {
  const context = useContext(CarRentAppContext);

  if (context === undefined) {
    throw new Error(
      `useCarRentAppContext must be used within a CarRentAppProvider`
    );
  }

  return context;
};

export { useCarRentAppContext };
