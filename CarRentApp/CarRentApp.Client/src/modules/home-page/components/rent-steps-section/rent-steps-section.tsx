import { Typography, Paper, Box } from "@material-ui/core";
import Timeline from "@material-ui/lab/Timeline";
import TimelineItem from "@material-ui/lab/TimelineItem";
import TimelineSeparator from "@material-ui/lab/TimelineSeparator";
import TimelineConnector from "@material-ui/lab/TimelineConnector";
import TimelineContent from "@material-ui/lab/TimelineContent";
import TimelineDot from "@material-ui/lab/TimelineDot";
import ExitToAppIcon from "@material-ui/icons/ExitToApp";
import VpnKeyIcon from "@material-ui/icons/VpnKey";
import DriveEtaIcon from "@material-ui/icons/DriveEta";

import { useStyles } from "./rent-steps-section.styles";

const RentStepsSection = () => {
  const classes = useStyles();

  return (
    <Box mt="20px">
      <Typography variant="h3" align="center">
        <b>How to order?</b>
      </Typography>

      <Timeline align="alternate">
        <TimelineItem classes={{ root: classes.timeLineItem }}>
          <TimelineSeparator>
            <TimelineDot color="primary">
              <ExitToAppIcon fontSize="large" />
            </TimelineDot>
            <TimelineConnector className={classes.secondaryTail} />
          </TimelineSeparator>
          <TimelineContent>
            <Paper elevation={5} className={classes.paper}>
              <Typography variant="h6" component="h1">
                First Step
              </Typography>
              <Typography>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
                eiusmod tempor incididunt
              </Typography>
            </Paper>
          </TimelineContent>
        </TimelineItem>
        <TimelineItem classes={{ root: classes.timeLineItem }}>
          <TimelineSeparator>
            <TimelineDot color="primary" variant="outlined">
              <VpnKeyIcon fontSize="large" />
            </TimelineDot>
            <TimelineConnector className={classes.secondaryTail} />
          </TimelineSeparator>
          <TimelineContent>
            <Paper elevation={5} className={classes.paper}>
              <Typography variant="h6" component="h1">
                Second Step
              </Typography>
              <Typography>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
                eiusmod tempor incididunt ut labore et dolore magna aliqua.
              </Typography>
            </Paper>
          </TimelineContent>
        </TimelineItem>
        <TimelineItem classes={{ root: classes.timeLineItem }}>
          <TimelineSeparator>
            <TimelineDot color="secondary">
              <DriveEtaIcon fontSize="large" />
            </TimelineDot>
          </TimelineSeparator>
          <TimelineContent>
            <Paper elevation={5} className={classes.paper}>
              <Typography variant="h6" component="h1">
                Third Step
              </Typography>
              <Typography>
                Lorem ipsum dolor sit amet, sed do eiusmod tempor incididunt ut
                labore et dolore magna aliqua.
              </Typography>
            </Paper>
          </TimelineContent>
        </TimelineItem>
      </Timeline>
    </Box>
  );
};

export { RentStepsSection };
