import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles(() => ({
  imageSlider: {
    width: "100%",

    "& .slick-arrow::before": {
      color: "black",
    },
  },
  gridContainer: {
    display: "flex",
    marginTop: 20,
    flexWrap: "wrap",
    padding: "10px",
  },
  pageContainer: {
    padding: "20px",
  },
  goBackButton: {
    marginTop: "30px",
  },
  rentButton: {
    color: "white",
  },
}));

export { useStyles };
