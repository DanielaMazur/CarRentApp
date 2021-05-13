import { Container } from "@material-ui/core";

import { RentStepsSection } from "./components/rent-steps-section";
import { VehiclesSection } from "./components/vehicles-section";

import CarPoster from "assets/images/car-poster.jpg";

import { useStyles } from "./home-page.styles";

const HomePage = () => {
  const classes = useStyles();

  return (
    <div className={classes.pageContainer}>
      <img src={CarPoster} alt="car" className={classes.bannerImage} />

      <Container maxWidth="md">
        <VehiclesSection />

        <RentStepsSection />
      </Container>
    </div>
  );
};

export { HomePage };
