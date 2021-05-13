import { useState } from "react";
import { Typography, Box, Button } from "@material-ui/core";

import { RentCarModal } from "components";

import { Car } from "types";

import { useStyles } from "./view-car-details.styles";

export type ViewCarDetailsProps = {
  car: Car.Car;
};

const ViewCarDetails = (props: ViewCarDetailsProps) => {
  const classes = useStyles();
  const [isRentModalOpen, setRentModalOpen] = useState(false);

  const handleOpenRentModal = () => {
    setRentModalOpen(true);
  };

  const handleCloseRentModal = () => {
    setRentModalOpen(false);
  };

  const handleConfirmRent = () => {};

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
        <Typography variant="h3">Price: {props.car.pricePerDay}</Typography>

        <Button
          className={classes.rentButton}
          variant="contained"
          color="primary"
          onClick={handleOpenRentModal}
        >
          Rent
        </Button>

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
