import { useQuery, UseQueryResult } from "@tanstack/react-query";
import axios from "axios";
import { AccountTypes } from "./accountsTypes";


const getUsers = (): Promise<AccountTypes> =>
    axios
        .get(`api/user`)
        .then(({ data }) => data);

export const useUsers = (): UseQueryResult<AccountTypes> => {
    return useQuery<AccountTypes>(["users"], getUsers)
}
