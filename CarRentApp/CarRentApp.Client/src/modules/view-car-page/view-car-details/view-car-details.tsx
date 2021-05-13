import { useState } from "react";
import { Typography, Box, Button, Tooltip } from "@material-ui/core";

import { ReservationsService } from "services";
import { useAuth } from "services/authProvider";

import { useCarRentAppContext } from "context/useCarRentAppContext";
import { RentCarModal } from "components";

import { Car, Reservation } from "types";

import { useStyles } from "./view-car-details.styles";

export type ViewCarDetailsProps = {
  car: Car.Car;
};

const ViewCarDetails = (props: ViewCarDetailsProps) => {
  const classes = useStyles();

  const [isAuth] = useAuth();

  const [isRentModalOpen, setRentModalOpen] = useState(false);

  const {
    handlers: { addSnackbar },
  } = useCarRentAppContext();

  const handleOpenRentModal = () => {
    setRentModalOpen(true);
  };

  const handleCloseRentModal = () => {
    setRentModalOpen(false);
  };

  const handleConfirmRent = async (
    rentDetails: Reservation.ReservationForm
  ) => {
    try {
      const utcStartDate = new Date(
        rentDetails.startDate.getTime() - new Date().getTimezoneOffset() * 60000
      ).toISOString();

      const utcEndDate = new Date(
        rentDetails.endDate.getTime() - new Date().getTimezoneOffset() * 60000
      ).toISOString();

      const reservation = await ReservationsService.PostReservation({
        carId: props.car.id,
        startDate: utcStartDate,
        endDate: utcEndDate,
      });

      if (typeof reservation == "string") {
        throw new Error(reservation);
      }

      addSnackbar({
        status: "success",
        message: "The reservation was successfully saved!",
      });
    } catch (error) {
      addSnackbar({
        status: "error",
        message: error.message,
      });
    }
  };

  return (
    <>
      <Typography variant="h3">
        {props.car.brand} {props.car.model}
      </Typography>
      <Typography variant="h5">Fuel: {props.car.fuel}</Typography>
      <Typography variant="h5">
        Transmission: {props.car.transmission}
      </Typography>
      <Typography variant="h5">Car Body: {props.car.body}</Typography>
      <Typography variant="h5">
        Fabrication Year:
        {new Date(`${props.car.fabricationYear}`).getFullYear()}
      </Typography>
      <Typography variant="h5">
        Registration Number: {props.car.registrationNumber}
      </Typography>
      <Typography variant="h5">
        Number Of Seats: {props.car.numberOfSeats}
      </Typography>
      <Typography variant="h5">
        Number Of Doors: {props.car.numberOfDoors}
      </Typography>
      <Typography variant="h5">
        Air Coditioning: {props.car.airCoditioning.toString()}
      </Typography>

      <Box
        mt="20px"
        display="flex"
        alignItems="center"
        justifyContent="space-between"
      >
        <Typography variant="h3" color="error">
          <b>Price: {props.car.pricePerDay}</b>
        </Typography>

        <Tooltip
          title={
            isAuth
              ? "Click here to make a reservation"
              : "You should login first"
          }
          aria-label="add"
        >
          <Box>
            <Button
              className={classes.rentButton}
              variant="contained"
              color="primary"
              onClick={handleOpenRentModal}
              disabled={!isAuth}
            >
              Rent
            </Button>
          </Box>
        </Tooltip>

        <RentCarModal
          carPrice={props.car.pricePerDay}
          isOpen={isRentModalOpen}
          handleConfirm={handleConfirmRent}
          handleClose={handleCloseRentModal}
        />
      </Box>
    </>
  );
};

export { ViewCarDetails };
