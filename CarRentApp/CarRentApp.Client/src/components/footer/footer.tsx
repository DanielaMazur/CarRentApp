import { Typography, AppBar, Container, Toolbar, Box } from "@material-ui/core";
import { useStyles } from "./footer.styles";

const Footer = () => {
  const classes = useStyles();

  return (
    <AppBar position="static" color="secondary" className={classes.footer}>
      <Container maxWidth="xl">
        <Toolbar>
          <Typography className={classes.footerText} variant="body1">
            © 2021 Carrent
          </Typography>

          <Box ml="auto">
            <Typography
              className={classes.footerText}
              variant="body1"
              align="right"
            >
              If you have any questions you can find us here : carrent@mail.com
            </Typography>
          </Box>
        </Toolbar>
      </Container>
    </AppBar>
  );
};

export { Footer };
