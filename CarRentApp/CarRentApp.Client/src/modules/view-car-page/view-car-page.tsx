import { useCallback, useEffect, useState } from "react";
import { useRouteMatch } from "react-router-dom";
import Slider from "react-slick";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import { Box, Typography, Container } from "@material-ui/core";

import { AccountService, CarService } from "services";
import { useCarRentAppContext } from "context/useCarRentAppContext";

import { Car } from "types";

import { useStyles } from "./view-car-page.styles";

const SliderSettings = {
  dots: true,
  infinite: true,
  speed: 500,
  slidesToShow: 1,
  slidesToScroll: 1,
  autoplay: true,
  autoplaySpeed: 8000,
  cssEase: "linear",
};

const ViewCarPage = () => {
  const classes = useStyles();
  const [currentCar, setCurrentCar] = useState<Car.Car | null>(null);

  const {
    params: { id: carId },
  } = useRouteMatch<{ id: string }>();

  const {
    cars,
    handlers: { addSnackbar },
  } = useCarRentAppContext();

  const fetchCarData = useCallback(async () => {
    const car = cars.find((car) => car.id === Number(carId));

    if (car != null) {
      setCurrentCar(car);

      return;
    }

    try {
      const fetchedCar = await CarService.GetCar(Number(carId));

      setCurrentCar(fetchedCar);
    } catch (error) {
      addSnackbar({
        status: "error",
        message: error.message,
      });
    }
  }, [addSnackbar, carId, cars]);

  useEffect(() => {
    fetchCarData();

    AccountService.GetCurrentAccount();
  }, [fetchCarData]);

  if (currentCar == null) {
    return <p>The car was not found</p>;
  }

  return (
    <Container>
      <Box className={classes.container}>
        <Slider className={classes.imageSlider} {...SliderSettings}>
          {currentCar?.photos.map((photo) => (
            <img key={photo.path} src={photo.path} alt="car" />
          ))}
        </Slider>

        <Box ml="40px">
          <Typography variant="h3">
            {currentCar?.brand} {currentCar?.model}
          </Typography>
          <Typography variant="h5">Fuel: {currentCar?.fuel}</Typography>
          <Typography variant="h5">
            Transmission: {currentCar?.transmission}
          </Typography>
          <Typography variant="h5">Car Body: {currentCar?.body}</Typography>
          <Typography variant="h5">
            Fabrication Year:
            {currentCar
              ? new Date(`${currentCar.fabricationYear}`).getFullYear()
              : 0}
          </Typography>
          <Typography variant="h5">
            Registration Number: {currentCar?.registrationNumber}
          </Typography>
          <Typography variant="h5">
            Number Of Seats: {currentCar?.numberOfSeats}
          </Typography>
          <Typography variant="h5">
            Number Of Doors: {currentCar?.numberOfDoors}
          </Typography>
          <Typography variant="h5">
            Air Coditioning: {currentCar?.airCoditioning.toString()}
          </Typography>

          <Typography variant="h2">Price: {currentCar?.pricePerDay}</Typography>
        </Box>
      </Box>
    </Container>
  );
};

export { ViewCarPage };
