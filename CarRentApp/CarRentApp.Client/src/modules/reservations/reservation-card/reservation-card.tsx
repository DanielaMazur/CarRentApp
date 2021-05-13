import { Paper, Grid, Typography } from "@material-ui/core";

import { getReservationPrice } from "utils/reservation-price.utils";

import { Reservation } from "types";

import { useStyles } from "./reservation-card.styles";

export type ReservationCardProps = {
  reservation: Reservation.Reservation;
};

const ReservationCard = (props: ReservationCardProps) => {
  const { car } = props.reservation;
  const classes = useStyles({
    imageUrl: props.reservation.car?.photos?.[0]?.path,
  });

  const reservationPrice = getReservationPrice(
    new Date(props.reservation.startDate),
    new Date(props.reservation.endDate),
    car?.pricePerDay || 0
  );

  return (
    <Paper>
      <Grid container>
        <Grid item xs={6}>
          <Typography variant="h5">{car?.brand}</Typography>
          <Typography>{car?.model}</Typography>
          <Typography>Start Date {props.reservation.startDate}</Typography>
          <Typography>End Date {props.reservation.endDate}</Typography>
          <Typography>Price {reservationPrice.toFixed(0)}</Typography>
        </Grid>
        <Grid item xs={6} className={classes.carImage}></Grid>
      </Grid>
    </Paper>
  );
};

export { ReservationCard };
