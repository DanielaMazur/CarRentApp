import { useEffect } from "react";
import { useHistory, useRouteMatch } from "react-router-dom";
import Slider from "react-slick";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import { Grid, Container, Button } from "@material-ui/core";

import { CarService } from "services";
import { useFetch } from "hooks/useFetch";

import { LoadingPage } from "components/loading-page";

import { ViewCarDetails } from "./view-car-details";

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

  const {
    data: currentCar,
    fetch: fetchCar,
    isLoading,
  } = useFetch(CarService.GetCar);

  const {
    params: { id: carId },
  } = useRouteMatch<{ id: string }>();

  useEffect(() => {
    if (isNaN(Number(carId))) {
      return;
    }

    fetchCar(Number(carId));

    //eslint-disable-next-line
  }, [carId]);

  const handleGoBackToCars = () => {
    history.goBack();
  };

  if (isLoading) {
    return <LoadingPage />;
  }

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
        Go Back
      </Button>
    </Container>
  );
};

export { ViewCarPage };
