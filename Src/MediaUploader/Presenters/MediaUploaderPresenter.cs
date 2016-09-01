using System;
using Sitecore.SharedSource.MediaUploader.Views;

namespace Sitecore.SharedSource.MediaUploader.Presenters
{
    public class MediaUploaderPresenter
    {
        private readonly IMediaUploaderView _view;

        public MediaUploaderPresenter(IMediaUploaderView view)
        {
            if (view == null) throw new ArgumentNullException(nameof(view));
            this._view = view;
        }

        public void Initialize()
        {
        }
    }
}