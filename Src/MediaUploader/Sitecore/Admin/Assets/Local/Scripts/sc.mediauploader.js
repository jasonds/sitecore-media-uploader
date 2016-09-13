var sc = sc || {};

sc.mediauploader = (function($) {
    var pub = {};

    // Show loading overlay
    function showLoadingOverlay() {
        var $imgUploadLoadingIndicatorContainer = $('[id*=imgUploadLoadingIndicatorContainer]');
        $imgUploadLoadingIndicatorContainer.addClass('shown');
    }
    
    // View blob details
    pub.onViewDetails = function(details) {
        if (details) {
            var content = JSON.parse(details);
            if (content) {
                var $modal = $('#blobDetailsModal');
                var $name = $($modal.find('#blobDetailsContentName'));
                var $cdnEndpoint = $($modal.find('#blobDetailsContentCdnEndpoint'));
                var $storageEndpoint = $($modal.find('#blobDetailsContentStorageEndpoint'));

                $name.text(content.Name);
                $cdnEndpoint.val(content.CdnEndpoint);
                $storageEndpoint.text(content.StorageEndpoint);
            }
        }

        $('#blobDetailsModal').modal('show');

        return false;
    };

    // Handle delete client side
    pub.onDelete = function () {
        // Validate
        if (!confirm('Delete this blob?')) {
            return false;
        }

        // Proceed with deletion
        showLoadingOverlay();

        return true;
    };

    // Handle delete all client side
    pub.onDeleteAll = function () {
        // Validate
        var length = $('[id*=cbSelectRow]:checked').length;

        if (length > 0) {
            var message = 'Delete selected blobs?';
            if (length === 1) {
                message = 'Delete selected blob?';
            }

            if (!confirm(message)) {
                return false;
            }
        } else {
            alert('Select at least one blob.');
            return false;
        }

        // Proceed with deletion
        showLoadingOverlay();

        return true;
    };

    // Handle blob upload client side
    pub.onUpload = function () {
        showLoadingOverlay();
    };

    (function init() {
        // Set up the copy to clipboard click
        $("body").on("click", ".clipboard", function(e) {
            var $target = $(e.currentTarget);
            var $input = $target.next();

            if ($input.length === 1) {
                $input.select();

                try {
                    var result = document.execCommand('copy');
                    if (!result) {
                        console.error('Copying the CDN Endpoint to clipboard was unsuccessful');
                    }
                } catch (err) {
                    console.error('Error copying the CDN Endpoint to clipboard.');
                }
            }
        });

        // Wire up the check / uncheck all logic
        var $selectAllSelector = $('#mediaUploaderBlobList [id*=cbSelectAll]');
        var $selectRowSelector = $('#mediaUploaderBlobList [id*=cbSelectRow]');

        $selectAllSelector.click(function () {
            if ($(this).is(':checked')) {
                $selectRowSelector.prop('checked', true);
            } else {
                $selectRowSelector.prop('checked', false);
            }
        });
        $selectRowSelector.click(function () {
            if ($selectRowSelector.length === $('#mediaUploaderBlobList [id*=cbSelectRow]:checked').length) {
                $selectAllSelector.prop('checked', true);
            } else {
                $selectAllSelector.prop('checked', false);
            }
        });
    })();

    return pub;
})(jQuery);
