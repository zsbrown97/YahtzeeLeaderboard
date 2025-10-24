<script lang="ts">
    import * as NavigationMenu from "$lib/components/ui/navigation-menu/index";

    import { page } from "$app/stores";
</script>

<nav class="border-b border-gray-200 bg-gray-50 p-4 flex justify-center">
	<NavigationMenu.Root>
		<NavigationMenu.List>

			<NavigationMenu.Item>
				<NavigationMenu.Link
					href="/"
					class="px-4 py-2 rounded-md hover:bg-gray-100 transition"
				>
					Player Summary
				</NavigationMenu.Link>
			</NavigationMenu.Item>

			<NavigationMenu.Item>
				<NavigationMenu.Link
					href="/mostRecentGame"
					class="px-4 py-2 rounded-md hover:bg-gray-100 transition"
				>
					Most Recent Game
				</NavigationMenu.Link>
			</NavigationMenu.Item>

			<!-- Example dropdown (optional) -->
			<!--
			<NavigationMenuItem>
				<NavigationMenuTrigger>Players</NavigationMenuTrigger>
				<NavigationMenuContent>
					<div class="p-4 grid gap-2">
						<NavigationMenuLink href="/playerSummary">Summary</NavigationMenuLink>
						<NavigationMenuLink href="/playerStats">Stats</NavigationMenuLink>
					</div>
				</NavigationMenuContent>
			</NavigationMenuItem>
			-->
		</NavigationMenu.List>
	</NavigationMenu.Root>
</nav>