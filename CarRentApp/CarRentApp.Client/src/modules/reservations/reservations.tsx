import { useEffect } from "react";
import { Grid, Container } from "@material-ui/core";

import { ReservationsService } from "services";
import { useFetch } from "hooks/useFetch";

import { LoadingPage } from "components/loading-page";
import { ReservationCard } from "./reservation-card";

import { Reservation } from "types";

import { useStyles } from "./reservations.styles";

const Reservations = () => {
  const classes = useStyles();
  const {
    fetch: fetchReservations,
    data: reservations,
    isLoading,
  } = useFetch<Reservation.Reservation[]>(ReservationsService.GetReservations);

  useEffect(() => {
    fetchReservations();
  }, [fetchReservations]);

  if (isLoading) {
    return <LoadingPage />;
  }

  return (
    <Container maxWidth="lg" className={classes.container}>
      <Grid container spacing={4}>
        {reservations?.map((res) => (
          <Grid key={res.id} item md={6} xs={12}>
            <ReservationCard reservation={res} />
          </Grid>
        ))}
      </Grid>
    </Container>
  );
};

export { Reservations };
