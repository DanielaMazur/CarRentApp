import { Grid, Typography, Box } from "@material-ui/core";

import HowToOrder from "assets/images/how-to-order.png";

import { useStyles } from "./rent-details-section.styles";

const RentDetailsSection = () => {
  const classes = useStyles();

  return (
    <Grid container className={classes.rentCarStepsSection}>
      <Grid item sm={6} xs={12} className={classes.rentDetailsContainer}>
        <Box className={classes.rentStepTitleContainer}>
          <Box className={classes.stepContainer}>1</Box>
          <Box>
            <Typography variant="h6">First Step</Typography>
            <Typography>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
              eiusmod tempor incididunt ut labore et dolore magna aliqua.
            </Typography>
          </Box>
        </Box>

        <Box className={classes.rentStepTitleContainer}>
          <Box className={classes.stepContainer}>2</Box>
          <Box>
            <Typography variant="h6">Second Step</Typography>
            <Typography>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
              eiusmod tempor incididunt ut labore et dolore magna aliqua.
            </Typography>
          </Box>
        </Box>

        <Box className={classes.rentStepTitleContainer}>
          <Box className={classes.stepContainer}>3</Box>
          <Box>
            <Typography variant="h6">Third Step</Typography>
            <Typography>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
              eiusmod tempor incididunt ut labore et dolore magna aliqua.
            </Typography>
          </Box>
        </Box>
      </Grid>

      <Grid item sm={6} xs={12}>
        <img className={classes.rentImage} src={HowToOrder} alt="how" />
      </Grid>
    </Grid>
  );
};

export { RentDetailsSection };
