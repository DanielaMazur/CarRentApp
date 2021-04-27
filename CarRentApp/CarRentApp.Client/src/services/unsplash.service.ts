import { createApi } from "unsplash-js";
import { InitParams } from "unsplash-js/dist/helpers/request";

const unsplash = createApi({
  apiUrl: "https://api.unsplash.com",
  accessKey: process.env.REACT_APP_UNSPLASH_KEY,
} as InitParams);

export { unsplash };
