import { useEffect, useState } from "react";
import { Container, Grid } from "@material-ui/core";

import { CarService } from "services";

import { CarCard } from "./car-card";

import { Car } from "types";

import { useStyles } from "./cars-page.styles";

const CarsPage = () => {
  const classes = useStyles();

  const [cars, setCars] = useState<Car.Car[]>([]);
  const [isCarsLoading, setCarsLoading] = useState(false);

  useEffect(() => {
    fetchCars();
  }, []);

  const fetchCars = async () => {
    try {
      setCarsLoading(true);

      const cars = await CarService.GetCars();

      setCars(cars.data);
    } catch (error) {
      console.log(error);
    } finally {
      setCarsLoading(false);
    }
  };

  if (isCarsLoading) {
    return <p>Loading...</p>;
  }

  return (
    <Container maxWidth="lg" className={classes.pageContainer}>
      <Grid container spacing={2}>
        {cars.map((car) => (
          <Grid key={car.id} item xs={4}>
            <CarCard car={car} />
          </Grid>
        ))}
      </Grid>
    </Container>
  );
};

export { CarsPage };
