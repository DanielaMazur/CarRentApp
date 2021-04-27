import { ThemeProvider } from "@material-ui/core";
import { BrowserRouter } from "react-router-dom";

import { CarRentAppProvider } from "context/CarRentAppProvider";

import { ApplicationContainer } from "containers/application-container";
import { RouterContainer } from "containers/router-container";

import { theme } from "theme";

const App = () => {
  return (
    <BrowserRouter>
      <ThemeProvider theme={theme}>
        <CarRentAppProvider>
          <ApplicationContainer>
            <RouterContainer />
          </ApplicationContainer>
        </CarRentAppProvider>
      </ThemeProvider>
    </BrowserRouter>
  );
};

export default App;
