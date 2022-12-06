import { useQuery, UseQueryResult } from "@tanstack/react-query";
import axios from "axios";
import { UserTypes } from "./userTypes";

const getUserByLogin = (login:string): Promise<UserTypes> =>
  axios
    .get(`${login}`)
    .then(({ data }) => data);

export const useUserByLogin = (login:string): UseQueryResult<UserTypes> => {

  return useQuery<UserTypes>(["userByLogin", login], () => getUserByLogin(login))
}
