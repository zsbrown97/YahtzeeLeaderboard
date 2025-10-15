import { getPlayers } from "$lib/api/players";

export async function load({ fetch }) {
    const players = await getPlayers(fetch);
    return { players }
}