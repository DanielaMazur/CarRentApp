import { useState } from "react";

import { useCarRentAppContext } from "context/useCarRentAppContext";

const useFetch = <T>(
  service: (args: any) => Promise<T>,
  setContextState?: React.Dispatch<React.SetStateAction<T>>
) => {
  const [isLoading, setLoading] = useState(false);
  const [data, setData] = useState<T>();

  const {
    handlers: { addSnackbar },
  } = useCarRentAppContext();

  const fetch = async (...args: any) => {
    try {
      setLoading(true);

      const response = await service(args);

      setData(response);

      if (setContextState) {
        setContextState(response);
      }
    } catch (error) {
      addSnackbar({
        status: "error",
        message: error.message,
      });
    } finally {
      setLoading(false);
    }
  };

  return { isLoading, data, fetch };
};

export { useFetch };
