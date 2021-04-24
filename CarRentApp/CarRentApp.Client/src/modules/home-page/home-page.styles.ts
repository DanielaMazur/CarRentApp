import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles(() => ({
  pageContainer: {
    display: "flex",
    flexDirection: "column",
    overflow: "hidden",
  },
  bannerImage: {
    width: "100%",
  },
  sectionTitle: {
    textAlign: "center",
    fontWeight: "bold",
    margin: "30px 0",
  },
}));

export { useStyles };
