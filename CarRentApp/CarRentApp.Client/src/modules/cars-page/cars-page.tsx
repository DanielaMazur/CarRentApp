import { useEffect } from "react";
import { Container, Grid } from "@material-ui/core";
import { useHistory } from "react-router";

import { useCarRentAppContext } from "context/useCarRentAppContext";
import { CarService } from "services";
import { useFetch } from "hooks/useFetch";

import { LoadingPage } from "components/loading-page";

import { CarCard } from "./car-card";

import { useStyles } from "./cars-page.styles";

const CarsPage = () => {
  const classes = useStyles();
  const history = useHistory();

  const {
    handlers: { setCars },
  } = useCarRentAppContext();

  const {
    data: cars,
    fetch: fetchCars,
    isLoading: isCarsLoading,
  } = useFetch(CarService.GetCars, setCars);

  useEffect(() => {
    if (cars != null) {
      return;
    }

    fetchCars();

    //eslint-disable-next-line
  }, []);

  if (isCarsLoading) {
    return <LoadingPage />;
  }

  return (
    <Container maxWidth="lg" className={classes.pageContainer}>
      <Grid container spacing={2}>
        {cars?.map((car) => (
          <Grid
            key={car.id}
            item
            md={4}
            sm={6}
            xs={12}
            onClick={() => history.push(`/cars/${car.id}`)}
          >
            <CarCard car={car} />
          </Grid>
        ))}
      </Grid>
    </Container>
  );
};

export { CarsPage };
