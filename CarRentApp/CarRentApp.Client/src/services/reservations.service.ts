import { authFetch } from "./authProvider";

import { Reservation } from "types";

const GetReservations = () => {
  return authFetch<Reservation.Reservation[]>("/reservations");
};

const GetCarReservedDayRanges = (carId: number) => {
  return authFetch<Reservation.ReservedDayRanges>(
    `/reservations/car-reserved-days?carId=${carId}`
  );
};

const PostReservation = (newReservation: Reservation.PostReservation) => {
  return authFetch<Reservation.PostReservation>("/reservations", {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    body: JSON.stringify(newReservation),
  });
};

const ReservationsService = {
  GetReservations,
  PostReservation,
  GetCarReservedDayRanges,
};

export { ReservationsService };
