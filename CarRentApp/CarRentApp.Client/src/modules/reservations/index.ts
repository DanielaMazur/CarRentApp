import { Reservations } from "./reservations";

const ReservationsModule = {
  name: "Reservations",
  component: Reservations,
  path: "/reservations",
  exact: true,
  private: true,
};

export { ReservationsModule };
