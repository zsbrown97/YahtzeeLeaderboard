const API_URL = "http://localhost:5089/api";

export async function getPlayers(fetch: typeof window.fetch) {
    const res = await fetch(`${API_URL}/Player`);
    return res.json();
}