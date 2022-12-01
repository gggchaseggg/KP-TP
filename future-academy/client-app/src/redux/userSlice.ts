import {createSlice, PayloadAction} from "@reduxjs/toolkit";

type userTypes = {
  login: string;
  role: string;
};

const initialState: userTypes = {
  login: "",
  role: "",
};

const userSlice = createSlice({
  name: "user",
  initialState,
  reducers: {
    setUser(
      state,
      action: PayloadAction<userTypes>
    ) {
      Object.assign(state, action.payload);
    },
    dropUser(
      state
    ) {
      Object.assign(state, initialState);
    }
  },
});

export const {setUser, dropUser} = userSlice.actions;

export default userSlice.reducer;