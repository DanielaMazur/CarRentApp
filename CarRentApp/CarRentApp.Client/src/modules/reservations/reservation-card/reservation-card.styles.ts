import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles((theme) => ({
  carImage: {
    backgroundImage: (props: { imageUrl?: string }) => `url(${props.imageUrl})`,
    backgroundRepeat: "no-repeat",
    backgroundColor:
      theme.palette.type === "light"
        ? theme.palette.grey[50]
        : theme.palette.grey[900],
    backgroundSize: "cover",
    backgroundPosition: "center",
  },
}));

export { useStyles };
