import { createSlice } from "@reduxjs/toolkit";
import { obtenerCocteleria, listarCocteleria } from '../actions/actionCocteleria';

const initialState = {
  coctelerias: [],
  cocteleria: {},
  loading: false,
  error: null,
};

const CocteleriaSlice = createSlice({
  name: "getCocteleria",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(listarCocteleria.pending, (state) => {
        state.coctelerias = [];
        state.loading = true;
        state.error = null;
      })
      .addCase(listarCocteleria.fulfilled, (state, action) => {
        state.coctelerias = action.payload;
        state.loading = false;
        state.error = null;
      })
      .addCase(listarCocteleria.rejected, (state, action) => {
        state.coctelerias = [];
        state.loading = false;
        state.error = action.error.message;
      })
      .addCase(obtenerCocteleria.pending, (state) => {
        state.cocteleria = {};
        state.loading = true;
        state.error = null;
      })
      .addCase(obtenerCocteleria.fulfilled, (state, action) => {
        state.cocteleria = action.payload;
        state.loading = false;
        state.error = null;
      })
      .addCase(obtenerCocteleria.rejected, (state, action) => {
        state.cocteleria = {};
        state.loading = false;
        state.error = action.error.message;
      });
  },
});

export const getCocteleriaReducer = CocteleriaSlice.reducer;