import { useCallback, useEffect, useState } from "react";
import { useHistory, useRouteMatch } from "react-router-dom";
import Slider from "react-slick";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import { Grid, Container, Button } from "@material-ui/core";

import { CarService } from "services";
import { useCarRentAppContext } from "context/useCarRentAppContext";

import { ViewCarDetails } from "./view-car-details";

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
  const history = useHistory();
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
  }, [fetchCarData]);

  const handleGoBackToCars = () => {
    history.push("/cars");
  };

  if (currentCar == null) {
    return <p>The car was not found</p>;
  }

  return (
    <Container className={classes.pageContainer}>
      <Grid
        container
        className={classes.gridContainer}
        alignItems="center"
        justify="center"
        spacing={7}
      >
        <Grid item md={6} xs={12}>
          <Slider className={classes.imageSlider} {...SliderSettings}>
            {currentCar?.photos.map((photo) => (
              <img key={photo.path} src={photo.path} alt="car" />
            ))}
          </Slider>
        </Grid>

        <Grid item md={6} xs={12}>
          <ViewCarDetails car={currentCar} />
        </Grid>
      </Grid>

      <Button
        className={classes.goBackButton}
        variant="outlined"
        color="secondary"
        onClick={handleGoBackToCars}
      >
        Go Back to all cars
      </Button>
    </Container>
  );
};

export { ViewCarPage };
