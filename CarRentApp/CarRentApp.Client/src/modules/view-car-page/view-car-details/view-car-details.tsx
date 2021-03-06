import { useCallback, useEffect, useState } from "react";
import { Typography, Box, Button } from "@material-ui/core";

import { ReservationsService } from "services";
import { useAuth } from "services/authProvider";
import { getUtcDate } from "utils/utc-date.utils";
import { getDatesFromDateRanges } from "utils/dates-from-date-ranges.utils";
import { useCarRentAppContext } from "context/useCarRentAppContext";

import { RentCarModal, RedirectAuthModal } from "components";

import { Car, Reservation } from "types";

import { useStyles } from "./view-car-details.styles";

export type ViewCarDetailsProps = {
  car: Car.Car;
};

const ViewCarDetails = (props: ViewCarDetailsProps) => {
  const classes = useStyles();

  const [isAuth] = useAuth();

  const [isRedirectAuthModalOpen, setRedirectAuthModalOpen] = useState(false);
  const [isRentModalOpen, setRentModalOpen] = useState(false);
  const [reservedDays, setReservedDays] = useState<Date[]>([]);

  const {
    handlers: { addSnackbar },
  } = useCarRentAppContext();

  const handleOpenModal = () => {
    if (isAuth) {
      setRentModalOpen(true);

      return;
    }
    setRedirectAuthModalOpen(true);
  };

  const handleCloseRentModal = () => {
    setRentModalOpen(false);
  };

  const handleCloseRedirectAuthModal = () => {
    setRedirectAuthModalOpen(false);
  };

  const handleConfirmRent = async (
    rentDetails: Reservation.ReservationForm
  ) => {
    try {
      const utcStartDate = getUtcDate(rentDetails.startDate);

      const utcEndDate = getUtcDate(rentDetails.endDate);

      const reservation = await ReservationsService.PostReservation({
        carId: props.car.id,
        startDate: utcStartDate,
        endDate: utcEndDate,
      });

      if (typeof reservation == "string") {
        throw new Error(reservation);
      }

      fetchReservedCarDays();

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

  const fetchReservedCarDays = useCallback(async () => {
    try {
      const reservedDayRanges =
        await ReservationsService.GetCarReservedDayRanges(props.car.id);

      setReservedDays(getDatesFromDateRanges(reservedDayRanges));
    } catch (error) {
      addSnackbar({
        status: "error",
        message: error.message,
      });
    }
  }, [addSnackbar, props.car.id]);

  useEffect(() => {
    if (isAuth) {
      fetchReservedCarDays();
    }
  }, [isAuth, fetchReservedCarDays]);

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

        <Box>
          <Button
            className={classes.rentButton}
            variant="contained"
            color="primary"
            onClick={handleOpenModal}
          >
            Rent
          </Button>
        </Box>

        <RentCarModal
          disabledDates={reservedDays}
          carPrice={props.car.pricePerDay}
          isOpen={isRentModalOpen}
          handleConfirm={handleConfirmRent}
          handleClose={handleCloseRentModal}
        />

        <RedirectAuthModal
          isOpen={isRedirectAuthModalOpen}
          handleClose={handleCloseRedirectAuthModal}
        />
      </Box>
    </>
  );
};

export { ViewCarDetails };
