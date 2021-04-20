using System;
using System.Collections.Generic;
using Mapbox.Map;
using Mapbox.Platform;
using Mapbox.Unity;
using Mapbox.Unity.MeshGeneration.Data;
using UnityEngine;

namespace Mapbox.Unity.DataFetching
{
	public abstract class DataFetcher
	{
		public virtual void FetchData(DataFetcherParameters parameters)
		{
		}

		protected void EnqueueForFetching(FetchInfo info)
		{
			MapboxAccess.Instance.DataManager.EnqueueForFetching(info);
		}

		public virtual void CancelFetching(UnwrappedTileId tileUnwrappedTileId, string tilesetId)
		{
			MapboxAccess.Instance.DataManager.CancelFetching(tileUnwrappedTileId, tilesetId);
		}
	}

	public class DataFetcherParameters
	{
		public CanonicalTileId canonicalTileId;
		public string tilesetId;
		public UnityTile tile;
	}

	public class FetchInfo
	{
		public CanonicalTileId TileId;
		public string TilesetId;
		public Action Callback;
		public Tile RasterTile;
		public string ETag;

		public FetchInfo(CanonicalTileId tileId, string tilesetId, Tile tile, string eTag = "", Action callback = null)
		{
			TileId = tileId;
			TilesetId = tilesetId;
			RasterTile = tile;
			ETag = eTag;
			callback = callback;
		}

	}
}