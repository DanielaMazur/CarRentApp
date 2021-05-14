import { useEffect } from "react";
import { Container } from "@material-ui/core";

import { useFetch } from "hooks/useFetch";
import { CarFiltersService } from "services";

import { RentStepsSection } from "./components/rent-steps-section";
import { VehiclesSection } from "./components/vehicles-section";
import { LoadingPage } from "components/loading-page";

import CarPoster from "assets/images/car-poster.jpg";

import { useStyles } from "./home-page.styles";

const HomePage = () => {
  const classes = useStyles();

  const {
    data: carBodyFilters,
    fetch: fetchCarBodyFilters,
    isLoading,
  } = useFetch(CarFiltersService.GetCarBodyFilters);

  useEffect(() => {
    fetchCarBodyFilters(6);

    new Image().src = CarPoster;

    //eslint-disable-next-line
  }, []);

  if (isLoading) {
    return <LoadingPage />;
  }

  return (
    <div className={classes.pageContainer}>
      <img src={CarPoster} alt="car" className={classes.bannerImage} />

      <Container maxWidth="md">
        <VehiclesSection carBodyFilters={carBodyFilters} />

        <RentStepsSection />
      </Container>
    </div>
  );
};

export { HomePage };
