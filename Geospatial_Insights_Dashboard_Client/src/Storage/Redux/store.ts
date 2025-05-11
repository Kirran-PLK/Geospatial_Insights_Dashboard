import { configureStore } from "@reduxjs/toolkit";
import { GeoMapReducer } from "./GeoMapSlice";
import insightsApi from "../../Apis";

const store = configureStore({
  reducer: {
    GeoMapStore: GeoMapReducer,
    [insightsApi.reducerPath]: insightsApi.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(insightsApi.middleware),
});

export type RootState = ReturnType<typeof store.getState>;

export default store;
