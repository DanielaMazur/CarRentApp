import { BrowserRouter } from "react-router-dom";

import { ApplicationContainer } from "containers/application-container";
import { RouterContainer } from "containers/router-container";

const App = () => {
  return (
    <BrowserRouter>
      <ApplicationContainer />
      <RouterContainer />
    </BrowserRouter>
  );
};

export default App;
