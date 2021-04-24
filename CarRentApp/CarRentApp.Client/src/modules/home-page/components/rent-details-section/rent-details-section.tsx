import { Grid, Typography, Box } from "@material-ui/core";

import RentCarSteps from "assets/images/rent-car-steps.png";

import { useStyles } from "./rent-details-section.styles";

const RentDetailsSection = () => {
  const classes = useStyles();

  return (
    <div>
      <Grid container className={classes.rentCarStepsSection}>
        <Grid item xs={6}>
          <Typography variant="h4" color="secondary">
            How to order?
          </Typography>
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

        <Grid item xs={6}>
          <img src={RentCarSteps} alt="car" />
        </Grid>
      </Grid>
    </div>
  );
};

export { RentDetailsSection };
