import { useEffect } from "react";

import { ReservationsService } from "services";
import { useFetch } from "hooks/useFetch";

import { LoadingPage } from "components/loading-page";

import { Reservation } from "types";

const Reservations = () => {
  const {
    fetch: fetchReservations,
    data: reservations,
    isLoading,
  } = useFetch<Reservation.Reservation[]>(ReservationsService.GetReservations);

  useEffect(() => {
    fetchReservations();

    //eslint-disable-next-line
  }, []);

  if (isLoading) {
    return <LoadingPage />;
  }

  return (
    <div>
      {reservations?.map((res) => (
        <p>{res.endDate}</p>
      ))}
    </div>
  );
};

export { Reservations };
