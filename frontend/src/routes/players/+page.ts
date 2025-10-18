import { getPlayerSummaries, getMostRecentGames } from "$lib/api/players";

export async function load({ fetch }) {
    const players = await getPlayerSummaries(fetch);

    const mostRecentGames = await getMostRecentGames(fetch);


    return { players, mostRecentGames }
}