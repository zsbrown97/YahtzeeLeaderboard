import { getPlayerSummaries } from "$lib/api/players";

export async function load({ fetch }) {
    const players = await getPlayerSummaries(fetch);
    return { players }
}