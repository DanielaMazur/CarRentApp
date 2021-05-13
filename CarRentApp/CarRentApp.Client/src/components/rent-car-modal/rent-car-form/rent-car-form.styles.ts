import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles((theme) => ({
  form: {
    display: "flex",
    flexDirection: "column",
  },
  totalPrice: {
    margin: "10px 0",
  },
  dateRange: {
    margin: "auto",
    width: "90%",
    maxWidth: "90%",
    "& .rdrMonths .rdrMonth": {
      width: "100%",
    },
    "& .rdrMonthAndYearWrapper .rdrMonthAndYearPickers .rdrMonthPicker select":
      {
        [theme.breakpoints.down(385)]: {
          maxWidth: "80px",
        },
        [theme.breakpoints.down(370)]: {
          maxWidth: "72px",
        },
        [theme.breakpoints.down(355)]: {
          maxWidth: "64px",
        },
        [theme.breakpoints.down(335)]: {
          maxWidth: "57px",
        },
      },
    "& .rdrMonthAndYearWrapper .rdrMonthAndYearPickers .rdrYearPicker select": {
      [theme.breakpoints.down(385)]: {
        maxWidth: "80px",
      },
      [theme.breakpoints.down(370)]: {
        maxWidth: "72px",
      },
      [theme.breakpoints.down(355)]: {
        maxWidth: "64px",
      },
      [theme.breakpoints.down(335)]: {
        maxWidth: "57px",
      },
    },
  },
}));

export { useStyles };
