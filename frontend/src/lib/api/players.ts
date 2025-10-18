const API_URL = "http://localhost:5089/api/Player";

export async function getPlayerSummaries(fetch: typeof window.fetch) {
    const res = await fetch(`${API_URL}/playerSummaries`);
    return res.json();
}

export async function getMostRecentGames(fetch: typeof window.fetch) {
    const res = await fetch(`${API_URL}/mostRecentGames`);
    return res.json();

}