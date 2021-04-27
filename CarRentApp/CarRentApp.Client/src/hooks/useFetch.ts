import { useState } from "react";
import { AxiosResponse } from "axios";
import { useCarRentAppContext } from "context/useCarRentAppContext";

const useFetch = <T>(service: (args: any) => Promise<AxiosResponse<T>>) => {
  const [isLoading, setLoading] = useState(false);
  const [data, setData] = useState<T>();

  const {
    handlers: { addSnackbar },
  } = useCarRentAppContext();

  const fetch = async (...args: any) => {
    try {
      setLoading(true);

      const response = await service(args);

      setData(response.data);
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
