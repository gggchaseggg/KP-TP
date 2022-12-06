import {createSlice, PayloadAction} from "@reduxjs/toolkit";

type userTypes = {
  login: string | undefined;
  role: string | undefined;
};

const initialState: userTypes = {
  login: undefined,
  role: undefined,
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
      document.cookie = `role=${action.payload.role};`;
    },
    dropUser(
      state
    ) {
      Object.assign(state, initialState);
      document.cookie = "";
      localStorage.removeItem("login");
    }
  },
});

export const {setUser, dropUser} = userSlice.actions;

export default userSlice.reducer;