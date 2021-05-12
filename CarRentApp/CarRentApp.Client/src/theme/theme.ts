import { createMuiTheme, responsiveFontSizes } from "@material-ui/core";

let theme = createMuiTheme({
  palette: {
    primary: {
      main: "#E39300",
    },
    secondary: {
      main: "#1C1C1C",
    },
  },
});

theme = responsiveFontSizes(theme);

export { theme };
