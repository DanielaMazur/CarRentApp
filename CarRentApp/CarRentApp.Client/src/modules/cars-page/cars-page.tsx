import { useEffect } from "react";
import { Container, Grid } from "@material-ui/core";

import { CarService } from "services";
import { useFetch } from "hooks/useFetch";

import { CarCard } from "./car-card";

import { useStyles } from "./cars-page.styles";

const CarsPage = () => {
  const classes = useStyles();

  const { data: cars, fetch: fetchCars, isLoading: isCarsLoading } = useFetch(
    CarService.GetCars
  );

  useEffect(() => {
    if (cars != null) {
      return;
    }

    fetchCars();

    //eslint-disable-next-line
  }, []);

  if (isCarsLoading) {
    return <p>Loading...</p>;
  }

  return (
    <Container maxWidth="lg" className={classes.pageContainer}>
      <Grid container spacing={2}>
        {cars?.map((car) => (
          <Grid key={car.id} item xs={4}>
            <CarCard car={car} />
          </Grid>
        ))}
      </Grid>
    </Container>
  );
};

export { CarsPage };
